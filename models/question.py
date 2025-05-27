class Question:
    def __init__(self, question, answer, options):
        # Validering om alla delar är korrekta
        if not isinstance(question, str) or not isinstance(answer, str) or not isinstance(options, list):
            raise ValueError("Felaktiga indata. Förväntar mig en sträng för frågan och svaret, samt en lista för alternativ.")
        
        if len(options) < 2:
            raise ValueError("Frågan måste ha minst två alternativ.")
        
        self.question = question
        self.answer = answer
        self.options = options

    def to_dict(self):
        return {
            'question': self.question,
            'answer': self.answer,
            'options': self.options
        }

    @staticmethod
    def from_dict(data):
        # Validering av ordbokens struktur
        if 'question' not in data or 'answer' not in data or 'options' not in data:
            raise ValueError("Felaktig ordbokstruktur. Förväntar mig nycklarna 'question', 'answer' och 'options'.")
        
        return Question(data['question'], data['answer'], data['options'])
