import { useState } from "react";
import './RegisterUser.css';
import axios from "axios";

function RegisterUser(){
    const roles =["User","Admin"];
    const [email,setEmail] = useState("");
    const [password,setPassword] = useState("");
    const [firstname,setFirstName] = useState("");
    const [lastname,setLastName] = useState("");
    const [role,setRole] = useState("");
    var [emailError,setEmailError]=useState("");
    var checkUSerData = ()=>{
        if(email=='')
        {
            setEmailError("Username cannot be empty");
            return false;
        }
           
        if(password=='')
            return false;
        if(role=='Select Role')
            return false;
        return true;
    }
    const signUp = (event)=>{
        event.preventDefault();
        var checkData = checkUSerData();
        if(checkData==false)
        {
            alert('please check yor data')
            return;
        }
        
        axios.post("https://localhost:7211/api/User",{
            email: email,
            firstname:firstname,
            lastname:lastname,
            role:	role,
            password:password
    })
        .then((userData)=>{
            console.log(userData)
        })
        .catch((err)=>{
            console.log(err)
        })
    }
    
    return(
        <form className="registerForm">
            <label className="form-control">Email</label>
            <input type="text" className="form-control" value={email}
                    onChange={(e)=>{setEmail(e.target.value)}}/>
           <label className="alert alert-danger">{emailError}</label>
            <label className="form-control">Password</label>
            <input type="password" className="form-control" value={password}
                    onChange={(e)=>{setPassword(e.target.value)}}/>
            <label className="form-control">FirstName</label>
            <input type="text" className="form-control" value={firstname}
                    onChange={(e)=>{setFirstName(e.target.value)}}/>

            <label className="form-control">LastName</label>
            <input type="text" className="form-control" value={lastname}
                    onChange={(e)=>{setLastName(e.target.value)}}/>

            <label className="form-control">Role</label>
            <select className="form-select" onChange={(e)=>{setRole(e.target.value)}}>
                <option value="select">Select Role</option>
                {roles.map((r)=>
                    <option value={r} key={r}>{r}</option>
                )}
            </select>
            <br/>
            <button className="btn btn-primary button" onClick={signUp}>Sign Up</button>
            
            <button className="btn btn-danger button">Cancel</button>
        </form>
    );
}

export default RegisterUser;