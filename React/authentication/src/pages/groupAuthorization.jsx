import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import HomeAPI from "../api/HomeAPI";

export default function GroupAuthorization() {
    const[response, setResponse] = useState('')
    const navigate = useNavigate()

    const { id } = useParams()

    /** @type {HomeAPI} */
    const api = new HomeAPI()

    useEffect(() => {
        const fetchAuthorizedInfo = async () => {
            /** @type {number} */
            const groupId = Number.parseInt(id)

            /** @type {string} */
            const resp = await api.professorLogin(groupId)

            if(resp === 'Usuário Não Autorizado.') {
                alert('Usuário Não Autorizado! Redirecionando para a Tela de Login!')

                navigate('/login')
            }

            setResponse(resp)
        }

        fetchAuthorizedInfo()
    }, [])

    return (
        <div>
            {response}
        </div>
    )
}