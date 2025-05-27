import socket
import json

def main():
    client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    client.connect(("localhost", 12345))

    while True:
        data = client.recv(1024).decode()
        if not data:
            break

        try:
            message = json.loads(data)
        except json.JSONDecodeError:
            print(f"Fel: kunde inte läsa data från servern:\n{data}")
            continue

        msg_type = message.get("type")
        msg_data = message.get("data")

        if msg_type == "question":
            print(f"\n{msg_data['question']}")
            for idx, option in enumerate(msg_data['options']):
                print(f"{idx + 1}. {option}")
            choice = input("Ditt svar (skriv alternativet): ")
            client.send(choice.encode())

        elif msg_type == "info":
            print("\n" + msg_data)
            if "Tack för att du" in msg_data:
                break

    client.close()

if __name__ == "__main__":
    main()
