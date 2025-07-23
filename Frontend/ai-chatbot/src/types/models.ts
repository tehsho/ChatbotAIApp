

export interface User {
  id?: number;
  username: string;
  email?: string;
  role?: string;
  isActive?: boolean;
  createdAt?: string;
}

export interface Message {
  id?: number;
  userId?: number;
  content: string;       // maps to MessageText
  response?: string;     // maps to ResponseText
  timestamp?: string;    // maps to CreatedAt
}
