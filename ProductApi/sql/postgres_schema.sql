CREATE TABLE if not exists product(id SERIAL PRIMARY KEY,
                    name VARCHAR(255) NOT NULL,
                    price DOUBLE PRECISION NOT NULL
                    );