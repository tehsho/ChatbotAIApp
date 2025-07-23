import apiClient from '../api/apiClient';
import { Message } from '../types/models';
import { API_BASE_URL } from "../settings";

export async function getMessages(username?: string): Promise<Message[]> {
  const url = `${API_BASE_URL}/api/Chat/messages/user/${username}`;
  const res = await apiClient.get<Message[]>(url);
  return res.data;
}

export async function askAI(message: { userId?: number; content: string }): Promise<Message> {
  const res = await apiClient.post<Message>(`${API_BASE_URL}/api/Chat/ask`, message);
  return res.data; // Return full message including .content and .response
}
