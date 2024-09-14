import React, { useEffect, useState } from "react";
import HomeAPI from "../api/HomeAPI";

export default function HelloWorld() {
    const[response, setResponse] = useState('')

    /** @type {HomeAPI} */
    const api = new HomeAPI()

    useEffect(() => {
        const fetchHelloWorld = async () => {
            const resp = await api.helloWorld()

            setResponse(resp)
        }

        fetchHelloWorld()
    }, [])

    return (
        <div>
            {response}
        </div>
    )
}