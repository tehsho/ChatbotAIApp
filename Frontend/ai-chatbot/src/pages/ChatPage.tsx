import React, { useState, useRef, useEffect, KeyboardEvent } from 'react';
import { User, Message } from '../types/models';
import { getMessages, askAI } from '../services/chatService';
import ChatMessage from '../components/ChatMessage';

interface Props {
  user: User;
  onLogout: () => void;
}

const ChatPage: React.FC<Props> = ({ user, onLogout }) => {
  const [input, setInput] = useState('');
  const [messages, setMessages] = useState<Message[]>([]);
  const bottomRef = useRef<HTMLDivElement>(null);
  
  useEffect(() => {
    getMessages(user.username).then(setMessages);
  }, [user]);

  useEffect(() => {
    bottomRef.current?.scrollIntoView({ behavior: 'smooth' });
  }, [messages]);

const sendMessage = async () => {
  if (!input.trim()) return;

  const fullMsg = await askAI({ userId: user.id, content: input }); // Should return { content, response, ... }
  setMessages(prev => [...prev, fullMsg]);
  setInput('');
};

  const handleKeyDown = (e: KeyboardEvent<HTMLInputElement>) => {
    if (e.key === 'Enter') sendMessage();
  };

  return (
    <div className="container mt-4">
      <div className="d-flex justify-content-between mb-3">
        <h5>User: {user.username}</h5>
        <button className="btn btn-secondary btn-sm" onClick={onLogout}>Logout</button>
      </div>

      <div style={{ height: 400, overflowY: 'auto', border: '1px solid #ccc', padding: 10 }}>
        {messages.map((msg, idx) => <ChatMessage key={idx} msg={msg} />)}
        <div ref={bottomRef} />
      </div>

      <div className="input-group mt-3">
        <input
          type="text"
          className="form-control"
          placeholder="Ask a question..."
          value={input}
          onChange={e => setInput(e.target.value)}
          onKeyDown={handleKeyDown}
        />
        <button className="btn btn-primary" onClick={sendMessage}>Send</button>
      </div>
    </div>
  );
};

export default ChatPage;