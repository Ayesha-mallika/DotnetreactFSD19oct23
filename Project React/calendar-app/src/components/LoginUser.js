import { useState } from "react";
import axios from "axios";
import './LoginUser.css';

function LoginUser(){
    const [email,setEmail] = useState("");
    const [password,setPassword] = useState("");
    const [role,setRole] = useState("");


    const login = (event)=>{
        event.preventDefault();
        axios.post("https://localhost:7211/api/User/Login",{
            email: email,
            password:password,
            role:role
        })
        .then((userData)=>{
            var token = userData.data.token;
            localStorage.setItem("token",token);
            localStorage.setItem("email",email);
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

        <label className="form-control">Role</label>
        <input type="role" className="form-control" value={role}
                        onChange={(e)=>{setRole(e.target.value)}}/>

        <button className="btn btn-primary button" onClick={login}>Login</button>
        
        </form>
    </div>
);

}

export default LoginUser;