CREATE TABLE public.tb_m_msg (
    id              BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    msg_code        VARCHAR(20), 
    msg_desc        VARCHAR(20),
    create_by    	VARCHAR(20),
    create_date     TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
);

CREATE TABLE public.tb_t_question (
    id              BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    question        TEXT not null,
    answer			TEXT,
    create_date     TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE public.tb_t_choice_items (
    id              BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    ref_question_id INT REFERENCES tb_t_question(id), 
    choice_text   	TEXT NOT NULL,
    is_correct		VARCHAR(1),
    create_date     TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP
);



