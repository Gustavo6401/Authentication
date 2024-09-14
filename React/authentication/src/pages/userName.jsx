import { useEffect, useState } from "react";
import HomeAPI from "../api/HomeAPI";
import { useNavigate } from "react-router-dom";

export default function UserName() {
    const [response, setResponse] = useState('')
    const navigate = useNavigate()

    /** @type {HomeAPI} */
    const api = new HomeAPI()

    useEffect(() => {
        const fetchUserName = async () => {
            const resp = await api.userName()

            if(resp === 'Usuário Não Autorizado.') {
                alert('Usuário Não Autorizado! Redirecionando para a Tela de Login!')

                navigate('/login')
            }

            setResponse(resp)
        }

        fetchUserName()
    }, [])

    return (
        <div>
            {response}
        </div>
    )
}