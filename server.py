import socket
import threading
import json
from models.question import Question

def load_questions():
    with open("C:/Users/elias.fritioff/Programmering 2/Slut-Uppgift/quiz/data/questions.json", "r", encoding="utf-8") as f:
        data = json.load(f)
    return [Question.from_dict(q) for q in data]

def send_json(client, data):
    client.send(json.dumps(data).encode())

def recv_text(client):
    return client.recv(1024).decode().strip()

def handle_game(player1, player2, questions):
    scores = {player1: 0, player2: 0}
    players = [player1, player2]

    for q in questions:
        # Skicka samma fråga till båda
        question_msg = {
            "type": "question",
            "data": q.to_dict()
        }
        for p in players:
            send_json(p, question_msg)

        # Ta emot svar från båda
        answers = {}
        for p in players:
            answers[p] = recv_text(p)
            print(f"Spelare {players.index(p)+1} svarade: {answers[p]}")

        # Skicka feedback och uppdatera poäng
        for p in players:
            if answers[p].lower() == q.answer.lower():
                scores[p] += 1
                feedback = {"type": "info", "data": "Rätt svar!"}
            else:
                feedback = {"type": "info", "data": f"Fel svar! Rätt svar är: {q.answer}"}
            send_json(p, feedback)

    # Skicka resultat
    p1_score = scores[player1]
    p2_score = scores[player2]

    result1 = f"Du fick {p1_score} poäng. Motståndaren fick {p2_score}."
    result2 = f"Du fick {p2_score} poäng. Motståndaren fick {p1_score}."

    send_json(player1, {"type": "info", "data": result1 + "\nTack för att du spelade!"})
    send_json(player2, {"type": "info", "data": result2 + "\nTack för att du spelade!"})

    player1.close()
    player2.close()

def main():
    server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server.bind(("0.0.0.0", 12345))
    server.listen()
    print("Server igång. Väntar på två spelare...")

    questions = load_questions()
    clients = []

    while len(clients) < 2:
        client, addr = server.accept()
        print(f"{addr} anslöt som spelare {len(clients)+1}.")
        clients.append(client)

    # Starta spel i ny tråd
    game_thread = threading.Thread(target=handle_game, args=(clients[0], clients[1], questions))
    game_thread.start()

if __name__ == "__main__":
    main()
