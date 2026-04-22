CREATE TABLE IF NOT EXISTS macro (
    id UUID primary key,
    name VARCHAR(150) NOT NULL,
    device_id UUID REFERENCES device(id),
    created_by UUID REFERENCES user_account(id),
    created_at TIMESTAMPTZ DEFAULT NOW()
   );