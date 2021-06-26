import axios, { AxiosResponse } from 'axios';
import { Activity } from '../models/activity';

const sleep = (delay: number) => {
    return new Promise((resolve) => {
        setTimeout(resolve, delay)
    })
}

axios.defaults.baseURL = 'http://localhost:44392/api';

axios.interceptors.response.use(async response => {
    try {
        await sleep(1000);
        return response;
    } catch (error) {
        console.log(error);
        return await Promise.reject(error);
    }
})


const responseBody = <T extends object>(response: AxiosResponse<T>) => response.data;

const requests = {
    get: <T extends object>(url: string) => axios.get<T>(url).then(responseBody),
    post: <T extends object>(url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    put: <T extends object>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    del: <T extends object>(url: string) => axios.delete<T>(url).then(responseBody),
}



const Activities = {
    list: () => requests.get<Activity[]>('/activities'),
    details: (id: string) => requests.get<Activity>(`/activities/${id}`),
    create: (activity: Activity) => requests.post('/activities', activity),
    update: (activity: Activity) => requests.put(`/activities/${activity.id}`, activity),
    delete: (id: string) => requests.del(`/activities/${id}`)
}

const agent = {
    Activities
}

export default agent;