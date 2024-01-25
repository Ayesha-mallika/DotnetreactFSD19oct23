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

 

  return (
    <div className="events">
      <div>
          <MyCalendar events={eventList}/>
        </div>
    </div>
  );
}

export default Events;