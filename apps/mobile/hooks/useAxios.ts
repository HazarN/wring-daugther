import { API_URL } from '@env';
import axios, { AxiosInstance } from 'axios';
import { useEffect, useMemo } from 'react';

export function useAxios() {
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
        // FIXME
        const token = null;

        if (token) config.headers.Authorization = `Bearer ${token}`;

        return config;
      },
      (err) => Promise.reject(err)
    );

    // Response interceptor
    const responseInterceptor = axiosInstance.interceptors.response.use(
      (response) => response,
      (err) => {
        if (err.response.status === 401) console.warn('Unauthorized! Redirect to login.');

        return Promise.reject();
      }
    );

    return () => {
      axiosInstance.interceptors.request.eject(requestInterceptor);
      axiosInstance.interceptors.response.eject(responseInterceptor);
    };
  }, [axiosInstance]);

  return axiosInstance;
}
