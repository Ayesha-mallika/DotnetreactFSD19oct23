import { Link } from "react-router-dom";
import './Menu.css';

function Menu(){
  const logout=()=>{
    localStorage.clear();
   // navigate('/Home');
    window.location.reload();

 }
    return (
      <nav className="navbar fixed-top navbar-expand-sm navbar-light line pad ">
            <Link className="navbar-brand pad" to="/Home">My Calendar</Link>
            <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbar-collapse">☰</button> 
            <div className="collapse navbar-collapse" id="navbar-collapse">
                <ul className="nav navbar-nav ml-auto">
                {localStorage.getItem("token")? "" : <div> <li className="nav-item active">
                <Link className="nav-link" to="/login" >Register/Login</Link>
              </li>
              </div>}
              {localStorage.getItem("token")? <li className="nav-item">
              <Link className="nav-link" to="/GetAccess" >GetAccess</Link>
            </li> : "" }
            {localStorage.getItem("token")? <li className="nav-item">
              <Link className="nav-link" to="/profile" >Profile</Link>
            </li> : "" }
            {localStorage.getItem("token")? <li className="nav-item">
            <Link className="nav-link" onClick={logout}>logout</Link>
            </li> :"" }
                </ul>
            </div>
        </nav>
    );
}

export default Menu;