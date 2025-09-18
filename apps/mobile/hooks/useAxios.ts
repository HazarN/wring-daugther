import { API_URL } from '@env';
import axios, { AxiosInstance } from 'axios';
import { useEffect, useMemo } from 'react';
import { useAuth } from './useAuth';

export function useAxios() {
  const { accessToken, refreshToken, logout, setAccessToken } = useAuth();

  const axiosInstance: AxiosInstance = useMemo(
    () =>
      axios.create({
        baseURL: API_URL,
        timeout: 10_000,
        headers: {
          'Content-Type': 'application/json',
        },
      }),
    []
  );

  useEffect(() => {
    // Request interceptor
    const requestInterceptor = axiosInstance.interceptors.request.use(
      async (config) => {
        if (accessToken) config.headers.Authorization = `Bearer ${accessToken}`;

        return config;
      },
      (err) => Promise.reject(err)
    );

    // Response interceptor
    const responseInterceptor = axiosInstance.interceptors.response.use(
      (response) => response,
      async (err) => {
        if (err.response?.status === 401 && refreshToken) {
          try {
            const res = await axiosInstance.post(`Auth/refresh-token`, {
              refreshToken,
              // FIXME also userId needed
            });

            const newAccessToken = res.data.accessToken;
            setAccessToken(newAccessToken);

            err.config.headers.Authorization = `Bearer ${newAccessToken}`;
            return axiosInstance(err.config);
          } catch (refreshErr) {
            console.warn('Refresh failed, logging out...');
            logout();
          }
        }

        return Promise.reject(err);
      }
    );

    return () => {
      axiosInstance.interceptors.request.eject(requestInterceptor);
      axiosInstance.interceptors.response.eject(responseInterceptor);
    };
  }, [axiosInstance]);

  return axiosInstance;
}
