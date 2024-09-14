import React from 'react'
import ReactDOM from 'react-dom/client'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import App from './App.jsx'
import './index.css'
import HelloWorld from './pages/helloWorld.jsx'
import Login from './pages/login.jsx'
import Logout from './pages/logout.jsx'
import UserName from './pages/userName.jsx'
import GroupAuthorization from './pages/groupAuthorization.jsx'

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <BrowserRouter>
      <Routes>
        <Route path='/' exact={true} element={<App />} />
        <Route path='/HelloWorld' element={<HelloWorld />} />
        <Route path='/login' element={<Login />} />
        <Route path='/logout' element={<Logout />} />
        <Route path='/UsuarioLogado' element={<UserName />} />
        <Route path='/GroupAuthorization/:id' element={ <GroupAuthorization />} />
      </Routes>
    </BrowserRouter>
  </React.StrictMode>,
)
