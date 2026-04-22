CREATE TABLE IF NOT EXISTS macro_step (
    id UUID primary key,
    macro_id UUID REFERENCES macro(id) ON DELETE CASCADE,
    step_order INTEGER NOT NULL,
    command TEXT NOT NULL,
    expected_pattern TEXT,
    auto_confirm BOOLEAN DEFAULT FALSE,
    delay_ms INTEGER DEFAULT 0
);