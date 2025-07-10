# AI Pull Requst Review Bot

This project are a AI base tool to automatic review pull requests in many coding langauges like Python, Java, C#, JavaScript and more. It help developer by find common issue in code before human reviewer is done.

## Why We Make This

Code review is tiring and sometime reviewer miss some important problem. Our bot solved this by using GPT model 4o to check PRs and give comments fastly. It helps to improves code quality and reduce bugs to production.

## Key Feature

- Support many langauge like Python, Java, C Sharp, Node, TypeScripts, etc.
- Detects securitys issue, bad naming convension, deprecated API and unhandled error.
- Suggest missing testcases or poor perfomance logic.
- Integrate with GitHub PR for comment on changed file.
- Can reading full files or just diff base on configs.

## How It's Works

1. Dev open PRs on repos.
2. GitHub Action is trigger and extract diff or change code.
3. The AI get codes and analyze it to finding mistake or warn.
4. Feedbacks are post direct to PRs as comment with line numbers.

## Technology Use

- OpenAI GPT-4o model or GPT-3.5 Turbo (configurabled)
- GitHub Actions for CI pipline
- Custom promt engine with retrying if model fails
- NodeJS / Python scripting for handling requests and responsed

## Limitation

- AI maybe give wrong suggestions if diffs are too smaller or context missing
- Depend on Open AI API and Internet conection
- Big PRs might hit token limit or be slow on responsing

## TODO

- Added langauge specific rule (like pylints, ESLint etc)
- Add web dashbord to seeing review histories
- Multi-model fallback and fine tune prompts per repos

## How to Use

1. Fork repo and setup secrects like `OPENAI_KEY` and `CHATGPT_MODEL`
2. Turn on GitHub Action in your repository
3. Make a PRs with some code
4. Wait few seconds and look the comments in your pull requesting
