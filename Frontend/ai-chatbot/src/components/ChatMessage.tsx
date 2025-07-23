import React from 'react';
import { Message } from '../types/models';

type Props = {
  msg: Message;
};

const ChatMessage: React.FC<Props> = ({ msg }) => (   
  <div className="form-control p-4 mb-4 shadow-md max-w-3xl mx-auto">
    <strong className="text-sm text-gray-600 mb-1">You:</strong>
    <div className="mb-2 whitespace-pre-wrap">{msg.content}</div>

    <div className="border-t border-gray-200 my-2" />

    <strong className="text-sm text-gray-600 mb-1">AI:</strong>
    <div className="whitespace-pre-wrap">{msg.response}</div>
  </div>
);

export default ChatMessage;
