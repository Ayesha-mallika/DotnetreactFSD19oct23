import axios from "axios";
import { useState,useEffect } from "react";
import MyCalendar from './MyCalendar';
import './Events.css';

function Events() {
  const [email, setEmail] = useState(localStorage.getItem("email"));
  const [eventList, setEventList] = useState([]);
  useEffect(()=>{
    getEvents();
  },[])

  const getEvents = () => {
    
    console.log(email);
    axios.get('https://localhost:7211/api/Event', {
      params: {
        userId: email
      }
    })
    .then((response) => {
      const posts = response.data;
      console.log(posts);
      setEventList(posts);
    })
    .catch(function (error) {
      console.log(error);
    });
  }

  //var checkEvents = eventList.length > 0 ? true : false;

  return (
    <div className="searchBox">
      <h1 className="alert alert-success">Event Calendar</h1>
      {/* <form>
        <br />
        <div class="row">
          <input id="pemail" type="text" class="form-control" value={email} onChange={(e) => { setEmail(e.target.value) }} />
        </div>
        <div class="row">
          <button className="btn btn-success" onClick={getEvents}>Get All Events</button>
        </div>
      </form> */}

      {/*{checkEvents ? (
        <div>
          <MyCalendar events={eventList}/>
        </div>
      ) : (
        <div>No events available yet</div>
      )}*/}
      <div>
          <MyCalendar events={eventList}/>
        </div>
    </div>
  );
}

export default Events;