import { useState } from "react";
import axios from "axios";
import './Login.css';
import { useNavigate } from "react-router-dom";

function Login(){
    const [email,setEmail] = useState("");
    const [password,setPassword] = useState("");
    const navigate =useNavigate();

    const login = (event)=>{
        event.preventDefault();
        axios.post("https://localhost:7211/api/User/Login",{
            email: email,
            password:password
        })
        .then((userData)=>{
            var token = userData.data.token;
            localStorage.setItem("token",token);
            localStorage.setItem("email",email);
            navigate("/events");
            window.location.reload();
        })
        .catch((err)=>{
            console.log(err)
        })
    } 
return(

    <div className="login">
       
    <div className="log">
        <form className="loginForm">
            <h3>Login</h3>
            <label className="form-control">Email</label>
            <input type="email" className="form-control" value={email} onChange={(e)=>{setEmail(e.target.value)}}/>
            <label className="form-control">Password</label>
            <input type="password" className="form-control" value={password} onChange={(e)=>{setPassword(e.target.value)}}/>
            <button className="btn btn-primary button" onClick={login}>Login</button>
            <br/>
            <br/>
            <p> New User? Register Here <a href="/">Register</a></p>
        </form>
    </div>
</div>

);

}

export default Login;