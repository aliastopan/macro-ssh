-- Migrations

CREATE TABLE IF NOT EXISTS user_account (
    id                UUID         PRIMARY KEY DEFAULT gen_random_uuid(),
    username          VARCHAR(100) NOT NULL UNIQUE,
    password_hash     VARCHAR(255) NOT NULL,
    role              VARCHAR(20)  NOT NULL DEFAULT 'teknisi',
    created_at        TIMESTAMP    NOT NULL DEFAULT NOW()
);

-- IDEMPOTENT: dijalankan berkali-kali namun hasilnya tetap sama.

CREATE TABLE IF NOT EXISTS macro (
    id                  UUID          PRIMARY KEY DEFAULT gen_random_uuid(),
    name                VARCHAR(100)  NOT NULL,
    description         TEXT,
    button_name         VARCHAR(100)  NOT NULL,
    jumphost           VARCHAR(255)  NOT NULL,
    jump_port           INT           NOT NULL DEFAULT 21112,
    olt_name            VARCHAR(255)  NOT NULL,
    olt_username        VARCHAR(100)  NOT NULL,
    olt_pass_encrypted  VARCHAR(255)  NOT NULL,
    vendor              VARCHAR(100),
    command             TEXT          NOT NULL,
    extra_steps         TEXT,
    is_active           BOOLEAN       NOT NULL DEFAULT TRUE,
    expires_at          TIMESTAMP,
    created_by          UUID          REFERENCES user_account(id),
    created_at          TIMESTAMP     NOT NULL DEFAULT NOW(),
    updated_at          TIMESTAMP     NOT NULL DEFAULT NOW()
);

CREATE OR REPLACE FUNCTION update_updated_at()
RETURNS TRIGGER AS $$
BEGIN
    NEW.updated_at = NOW();
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE TRIGGER macro_updated_at
    BEFORE UPDATE ON macro
    FOR EACH ROW
    EXECUTE FUNCTION update_updated_at();