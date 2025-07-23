import React, { useState, FormEvent } from 'react';
import { useNavigate } from 'react-router-dom';
import { login } from '../services/authService';
import { User } from '../types/models';

interface Props {
  onLogin: (user: User) => void;
}

const LoginPage: React.FC<Props> = ({ onLogin }) => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState<string | null>(null);
  const navigate = useNavigate();

const handleSubmit = async (e: FormEvent) => {
  e.preventDefault();
  try {
    const user = await login(username, password);
    onLogin(user);
    navigate('/chat');
  } catch (err: any) {
    if (err.response && err.response.data && err.response.data.message) {
      setError(err.response.data.message); // API sent an error message
    } else if (err.message) {
      setError(`Error: ${err.message}`); // JS-level error (e.g., network)
    } else {
      setError('An unexpected error occurred');
    }
    console.error('Login error:', err); // Log full error for debugging
  }
};

  return (
    <div className="container mt-5" style={{ maxWidth: 400 }}>
      <h2>Login</h2>
      {error && <div className="alert alert-danger">{error}</div>}
      <form onSubmit={handleSubmit}>
        <input type="text" className="form-control mb-3" placeholder="Username"
          value={username} onChange={e => setUsername(e.target.value)} required />
        <input type="password" className="form-control mb-3" placeholder="Password"
          value={password} onChange={e => setPassword(e.target.value)} required />
        <button className="btn btn-primary" type="submit">Login</button>
      </form>
    </div>
  );
};

export default LoginPage;