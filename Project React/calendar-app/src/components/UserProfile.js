import axios from "axios";
import { useEffect, useState } from "react";

function UserProfile(){
    const [user,setUser]=useState({});

    useEffect(()=>{
        getUsers();
    },[]);

    const getUsers = ()=>{
        axios.get('https://localhost:7211/api/User',{
            params: {
                Email : localStorage.getItem("email")
            }
          })
          .then((response) => {
            const posts = response.data[0];
            console.log(posts);
            setUser(posts);
            console.log(user);
        })
        .catch(function (error) {
            console.log(error);
        })
    }

return(
    <div>
        <form className="registerForm">
            <label className="form-control">Email</label>
            <input type="text" className="form-control" value={user.email} disabled/>
           <br/>
            <label className="form-control">FirstName</label>
                <input type="text" className="form-control" value={user.firstName} disabled/>
             <br/>
            <label className="form-control">LastName</label>
                <input type="text" className="form-control" value={user.lastName} disabled/>
             <br/>
            <label className="form-control">Role</label>
                <input type="text" className="form-control" value={user.role} disabled/>
            <br/>
            
        </form>
    </div>
)
    
}

export default UserProfile;