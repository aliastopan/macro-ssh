CREATE TABLE IF NOT EXISTS user_account (
    id UUID primary key,
    username varchar(100) unique not null,
    password_hash TEXT NOT NULL,
    role VARCHAR(50) NOT NULL,
    is_active BOOLEAN DEFAULT TRUE,
    created_at TIMESTAMPTZ DEFAULT NOW()
);