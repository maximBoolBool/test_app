
CREATE DATABASE question_db;

CREATE TABLE surveys(
    id BIGSERIAL PRIMARY KEY,
    name TEXT NOT NULL,
    created TIMESTAMP WITH TIME ZONE NOT NULL
);

CREATE TABLE questions(
    id BIGSERIAL PRIMARY KEY,
    question TEXT NOT NULL,
    place_in_survey INT NOT NULL,
    survey_id BIGINT REFERENCES surveys(id) NOT NULL,
    is_required BOOLEAN NOT NULL,
    is_multi_choice BOOLEAN NOT NULl
);

CREATE TABLE answers(
    id BIGSERIAL PRIMARY KEY,
    response TEXT NOT NULL,
    question_id BIGINT REFERENCES questions(id) NOT NULL
);

CREATE TABLE interviews(
    id BIGSERIAL PRIMARY KEY,
    "from" TIMESTAMP WITH TIME ZONE NOT NULL,
    survey_id BIGINT REFERENCES surveys(id)
);

CREATE TABLE results(
    id BIGSERIAL PRIMARY KEY,
    answer_id BIGINT REFERENCES answers(id),
    interview_id BIGINT REFERENCES interviews(id)
);


CREATE INDEX IX_answer_question_id
    ON answers
    USING hash(question_id);

CREATE INDEX IX_interviews_survey_id
    ON interviews
    USING hash (survey_id);

CREATE INDEX IX_questions_survey_id
    ON questions
    USING hash (survey_id);

CREATE INDEX IX_results_answer_id
    ON results
    USING  hash (answer_id);

CREATE INDEX IX_results_interview_id
    ON results
    USING hash (interview_id);

-- SQL для начального заполнения бд
-- INSERT INTO surveys (name, created)
-- VALUES ('First survey', NOW());
--
-- INSERT INTO questions (question, place_in_survey, survey_id, is_required, is_multi_choice)
-- VALUES
-- ('Question 1', 1, (SELECT id FROM surveys WHERE name = 'First survey'), true, false),
-- ('Question 3', 1, (SELECT id FROM surveys WHERE name = 'First survey'), true, false),
-- ('Question 2', 1, (SELECT id FROM surveys WHERE name = 'First survey'), true, false);
--
-- INSERT INTO answers (response, question_id)
-- VALUES
--   ('Answer 1', (SELECT id FROM questions WHERE question = 'Question 1')),
--   ('Answer 2', (SELECT id FROM questions WHERE question = 'Question 1')),
--   ('Answer 3', (SELECT id FROM questions WHERE question = 'Question 1')),
--   ('Answer 1', (SELECT id FROM questions WHERE question = 'Question 2')),
--   ('Answer 2', (SELECT id FROM questions WHERE question = 'Question 2')),
--   ('Answer 3', (SELECT id FROM questions WHERE question = 'Question 2')),
--   ('Answer 1', (SELECT id FROM questions WHERE question = 'Question 3')),
--   ('Answer 2', (SELECT id FROM questions WHERE question = 'Question 3')),
--   ('Answer 3', (SELECT id FROM questions WHERE question = 'Question 3'));
