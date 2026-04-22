CREATE TABLE IF NOT EXISTS device (
    id UUID primary key,
    name VARCHAR(150) NOT NULL,
    ip_address VARCHAR(50) NOT NULL,
    port INTEGER NOT NULL DEFAULT 22,
    username VARCHAR(100) NOT NULL,
    password_hash TEXT NOT NULL,
    vendor VARCHAR(50) NOT NULL,
    created_at TIMESTAMPTZ DEFAULT NOW()
);