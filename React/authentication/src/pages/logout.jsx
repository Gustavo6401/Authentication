import HomeAPI from "../api/HomeAPI";

export default function Logout() {
    /** @type {HomeAPI} */
    const api = new HomeAPI()

    const logout = async () => {
        /** @type {string} */
        const resp = await api.logout()

        alert(resp)
    }

    return (
        <button onClick={logout}>Logout</button>
    )
}