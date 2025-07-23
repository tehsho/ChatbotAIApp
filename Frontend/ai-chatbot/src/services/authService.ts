import apiClient from '../api/apiClient';
import { User } from '../types/models';
import { API_BASE_URL } from "../settings";

export async function login(username: string, password: string): Promise<User> {
  const res = await apiClient.post<User>(`${API_BASE_URL}/api/auth/login`, { username, password });
  return res.data;
}