import axios from 'axios'

export default class HomeAPI {
    /**
     * @returns {Promise<string>}
     */
    async helloWorld() {
        /** @type {import('axios').AxiosInstance} */
        const api = axios.create({
            baseURL: 'https://localhost:5001',
        })

        try {
            /** @type {import('axios').AxiosResponse} */
            const result = await api.get('/')

            /** @type {string} */
            const resp = result.data

            return resp
        } catch (error) {
            if (error.response) {
                console.error('Erro: ', error.response.data)
                console.log('Mensagem: ', error.response.message)
                console.log('Status: ', error.response.status)
                console.log('Headers: ', error.response.headers)
            } else if (error.request) {
                console.error('Nenhuma Resposta Recebida: ', error.request)
            } else {
                console.error('Erro na Configuração da Requisição')
            }

            throw error
        }
    }

    async test() {
        const api = axios.create({
            baseURL: 'https://localhost:5001/',
            withCredentials: true
        })

        try {
            /** @type {import('axios').AxiosResponse} */
            const result = await api.get('/test')

            /** @type {string} */
            const resp = result.data

            return resp
        } catch (error) {
            if (error.response) {
                console.error('Erro: ', error.response.data)
                console.log('Mensagem: ', error.response.message)
                console.log('Status: ', error.response.status)
                console.log('Headers: ', error.response.headers)
            } else if (error.request) {
                console.error('Nenhuma Resposta Recebida: ', error.request)
            } else {
                console.error('Erro na Configuração da Requisição')
            }

            throw error
        }
    }

    /**
     * @param {string} email 
     * @returns {Promise<string>}
     */
    async login(email) {
        /** @type {import('axios').AxiosInstance} */
        const api = axios.create({
            baseURL: 'https://localhost:5001',
            withCredentials: true
        })

        try {
            /** @type {import('axios').AxiosResponse} */
            const result = await api.post('/login', null, {
                headers: {
                    'email': email
                }
            })

            /** @type {string} */
            const resp = result.data

            return resp
        } catch (error) {
            if (error.response) {
                console.error('Erro: ', error.response.data)
                console.log('Mensagem: ', error.response.message)
                console.log('Status: ', error.response.status)
                console.log('Headers: ', error.response.headers)
            } else if (error.request) {
                console.error('Nenhuma Resposta Recebida: ', error.request)
            } else {
                console.error('Erro na Configuração da Requisição')
            }

            throw error
        }
    }

    /** 
     * @returns {Promise<string>}
     */
    async logout() {
        /** @type {import('axios').AxiosInstance} */
        const api = axios.create({
            baseURL: 'https://localhost:5001/',
            withCredentials: true
        })

        try {
            /** @type {import('axios').AxiosResponse} */
            const result = await api.post('logout/')

            /** @type {string} */
            const resp = result.data

            return resp
        } catch (error) {
            if (error.response) {
                console.error('Erro: ', error.response.data)
                console.log('Mensagem: ', error.response.message)
                console.log('Status: ', error.response.status)
                console.log('Headers: ', error.response.headers)
            } else if (error.request) {
                console.error('Nenhuma Resposta Recebida: ', error.request)
            } else {
                console.error('Erro na Configuração da Requisição')
            }

            throw error
        }
    }

    /**
     * @returns {Promise<string>}
     */
    async userName() {
        /** @type {import('axios').AxiosInstance} */
        const api = axios.create({
            baseURL: 'https://localhost:5001/',
            withCredentials: true
        })

        try {
            /** @type {import('axios').AxiosResponse} */
            const result = await api.get('/usuarioLogado')

            console.log(result.status)

            /** @type {string} */
            const resp = result.data

            return resp
        } catch (error) {
            if (error.response) {
                if(error.response.status === 401) {
                    console.log(401)

                    return 'Usuário Não Autorizado.'
                }
                console.error('Erro: ', error.response.data)
                console.log('Mensagem: ', error.response.message)
                console.log('Status: ', error.response.status)
                console.log('Headers: ', error.response.headers)
            } else if (error.request) {
                console.error('Nenhuma Resposta Recebida: ', error.request)
                console.log('Requisição: ', error.config)
            } else {
                console.error('Erro na Configuração da Requisição')
            }

            throw error
        }
    }

    /**
     * 
     * @param {number} group 
     */
    async professorLogin(group) 
    {
        /** @type {import('axios').AxiosInstance} */
        const api = axios.create({
            baseURL: 'https://localhost:5001',
            withCredentials: true
        })

        try {
            /** @type {import('axios').AxiosResponse} */
            const result = await api.get(`/GroupAuthorization`, { 
                headers: { 
                    'groupId': group.toString() 
                }
            })

            console.log(result.status)

            /** @type {string} */
            const resp = result.data

            return resp
        } catch (error) {
            if (error.response) {
                if(error.response.status === 401) {
                    console.log(401)

                    return 'Usuário Não Autorizado.'
                }
                console.error('Erro: ', error.response.data)
                console.log('Mensagem: ', error.response.message)
                console.log('Status: ', error.response.status)
                console.log('Headers: ', error.response.headers)
            } else if (error.request) {
                console.error('Nenhuma Resposta Recebida: ', error.request)
                console.log('Requisição: ', error.config)
            } else {
                console.error('Erro na Configuração da Requisição')
            }

            throw error
        }
    }
}