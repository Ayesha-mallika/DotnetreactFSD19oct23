import { Link } from "react-router-dom";
import './Menu.css';

function Menu(){
    return (
      <nav className="navbar navbar-expand-lg navbar-light bg-light">
  
        <div className="collapse navbar-collapse" id="navbarNav">
          <ul className="navbar-nav">
            <li className="nav-item active">
              <Link className="nav-link" to="/" >RegisterUser</Link>
            </li>
            <li className="nav-item ">
              <Link className="nav-link" to="loginuser" >LoginUser</Link>
            </li>
            <li className="nav-item ">
              <Link className="nav-link" to="mycalendar">MyCalendar</Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link" to="/events" >Events</Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link" to="/category" >Category</Link>
            </li>
            
          </ul>
        </div>
      </nav>
    );
}

export default Menu;