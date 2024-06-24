import { useState } from 'react';
import { useNavigate } from 'react-router-dom';

function Register() {
    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [phone, setPhone] = useState('');
    const [error, setError] = useState('');
    const navigate = useNavigate();

    const handleRegister = async () => {
        setError('');
        const user = { name, email, password, phone };

        const response = await fetch('/account/register', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(user),
        });

        if (response.ok) {
            navigate('/login');
        } else {
            const errorMessage = await response.text();
            setError(`Failed to register: ${errorMessage}`);
        }
    };

    return (
        <div>
            <h1>Register</h1>
            <input
                type="text"
                value={name}
                onChange={(e) => setName(e.target.value)}
                placeholder="Name"
            />
            <input
                type="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                placeholder="Email"
            />
            <input
                type="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                placeholder="Password"
            />
            <input
                type="text"
                value={phone}
                onChange={(e) => setPhone(e.target.value)}
                placeholder="Phone"
            />
            <button onClick={handleRegister}>Register</button>
            {error && <p style={{ color: 'red' }}>{error}</p>}
            <p>
                ALready have an account? <a href="/login">Log in</a>
            </p>
        </div>
    );
}

export default Register;
