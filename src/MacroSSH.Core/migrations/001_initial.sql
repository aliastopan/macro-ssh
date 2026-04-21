-- Migtations

CREATE TABLE IF NOT EXISTS user_account (
    id            UUID         PRIMARY KEY DEFAULT gen_random_uuid(),
    username      VARCHAR(100) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    role          VARCHAR(20)  NOT NULL DEFAULT 'teknisi',
    created_at    TIMESTAMP    NOT NULL DEFAULT NOW()
);

-- IDEMPOTENT: dijalankan berkali-kali namun hasilnya tetap sama.

CREATE TABLE IF NOT EXISTS macro (
    id          UUID         PRIMARY KEY DEFAULT gen_random_uuid(),
    label       VARCHAR(100) NOT NULL,
    command     TEXT         NOT NULL,
    created_by  UUID         REFERENCES user_account(id),
    created_at  TIMESTAMP    NOT NULL DEFAULT NOW()
);