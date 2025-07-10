from abc import ABC, abstractmethod
from ai.line_comment import LineComment

class AiBot(ABC):
    
    __no_response = "No critical issues found"
    __problems="errors, issues, potential crashes or unhandled exceptions"
    __chat_gpt_ask_long="""
Please perform a detailed analysis of the provided Git diff and the accompanying full file context. Your analysis should focus on identifying any potential issues, specifically:

    Security Vulnerabilities: Look for any code patterns or practices that may expose the application to security risks.
    Deprecated Methods or Libraries: Identify any methods or libraries that are no longer recommended for use and suggest alternatives if applicable.
    Violations of Language/Framework Best Practices: Check for any deviations from established best practices in the relevant programming language or framework.
    Code Smells: Detect any patterns in the code that may indicate deeper issues, such as poor design or maintainability concerns.
    Package Method Inconsistencies: Review the methods used from packages for consistency and potential vulnerabilities.
    General Code Quality Issues: Highlight any areas where the code could be improved for clarity, efficiency, or performance.
    General grammar and spelling check: Review grammatical and spelling errors for documentation only.

Should give a single issue for a single comment.
Response Format: For each identified issue, please respond in the following strict format:
"line_number : cause → effect"
 
If no issues are found, reply only with "{no_response}".
 
DIFF:
{diffs}
 
FULL CODE:
{code}
"""

    @abstractmethod
    def ai_request_diffs(self, code, diffs) -> str:
        pass

    @staticmethod
    def build_ask_text(code, diffs) -> str:
        return AiBot.__chat_gpt_ask_long.format(
            problems = AiBot.__problems,
            no_response = AiBot.__no_response,
            diffs = diffs,
            code = code,
        )

    @staticmethod
    def is_no_issues_text(source: str) -> bool:
        target = AiBot.__no_response.replace(" ", "")
        source_no_spaces = source.replace(" ", "")
        return source_no_spaces.startswith(target)
    
    @staticmethod
    def split_ai_response(input) -> list[LineComment]:
        if input is None or not input:
            return []
        
        lines = input.strip().split("\n")
        models = []

        for full_text in lines:
            number_str = ''
            number = 0
            full_text = full_text.strip()
            if len( full_text ) == 0:
                continue

            reading_number = True
            for char in full_text.strip():
                if reading_number:
                    if char.isdigit():
                        number_str += char
                    else:
                        break

            if number_str:
                number = int(number_str)

            models.append(LineComment(line = number, text = full_text))
        return models
    