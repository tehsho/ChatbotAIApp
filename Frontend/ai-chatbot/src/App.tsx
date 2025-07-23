import React, { useState } from 'react';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import ChatPage from './pages/ChatPage';
import LoginPage from './pages/LoginPage';
import { User } from './types/models';

const App: React.FC = () => {
  const [user, setUser] = useState<User | null>(null);

  return (
    <Router>
      <Routes>
        <Route path="/login" element={<LoginPage onLogin={setUser} />} />
        <Route path="/chat" element={user ? <ChatPage user={user} onLogout={() => setUser(null)} /> : <Navigate to="/login" />} />
        <Route path="*" element={<Navigate to={user ? '/chat' : '/login'} />} />
      </Routes>
    </Router>
  );
};

export default App;
