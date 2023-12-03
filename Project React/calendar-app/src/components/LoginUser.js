import { useState } from "react";
import axios from "axios";
import './LoginUser.css';

function LoginUser(){
    const [email,setEmail] = useState("");
    const [password,setPassword] = useState("");

    const login = (event)=>{
        event.preventDefault();
        axios.post("https://localhost:7211/api/User/Login",{
            email: email,
            password:password
        })
        .then((userData)=>{
            var token = userData.data.token;
            localStorage.setItem("token",token);
        })
        .catch((err)=>{
            console.log(err)
        })
    }
return(
    <div>
        <form className="form-group">
        <label className="form-control">Email</label>
        <input type="email" className="form-control" value={email}
                        onChange={(e)=>{setEmail(e.target.value)}}/>
            
        <label className="form-control">Password</label>
        <input type="password" className="form-control" value={password}
                        onChange={(e)=>{setPassword(e.target.value)}}/>

        <button className="btn btn-primary button" onClick={login}>Login</button>
        
        </form>
    </div>
);

}

export default LoginUser;