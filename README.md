# Coensio case study
## Running the project
- clone the repo
- cd into the repo
- run `docker compose up`
- run `dotnet ef migrations add InitialCreate`
- run `dotnet ef database update`
- open `http://localhost:8080/swagger/index.html`
## Basic usage
- `Login` endpoint is used to obtain a JWT.
- `Question` endpoints are used to create questions.
- `Test` endpoint is used to create a test with the given question ids.
- After creating questions and tests, `Answer` endpoints are used to answer questions with a `testId` and `questionId`.
- A `POST /Test/Calculate/{id}` request triggers the calculation of a test's score.
- A test's score can be inspected with the `GET /Test/{id}` endpoint.

## Possible improvements
- Unit tests
- Multiple choice question type's implementation is missing. It should be implemented.
- Ordering of the tests should be implemented.
- The user with the email address contained in the JWT should be able to interact only with their own tests. Right now, this feature is missing. Everyone who has a JWT is able to interact with every test.
