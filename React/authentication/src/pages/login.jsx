import React, { useState } from "react"
import HomeAPI from "../api/HomeAPI"

export default function Login() {
    const [email, setEmail] = useState('')
    /** @type {HomeAPI} */
    const api = new HomeAPI()

    const login = async () => {
        /** @type {string} */
        const resp = await api.login(email)

        alert(resp)
    }

    return (
        <div>
            <input onChange={e => setEmail(e.target.value)} type='email' />
            <button onClick={login}>Login</button>
        </div>
    )
}