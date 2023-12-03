import axios from "axios";
import { useState } from "react";
import "./GetAccess.css";
function GetAccess(){
    const [access,setAccess]=useState("");
    const [eventList,setEventList]=useState([])
    var getEvents = (event)=>{
        event.preventDefault();
        console.log(access);
        axios.get('https://localhost:7211/api/event/access',{
            params: {
                Access : access
            }
          })
          .then((response) => {
            const posts = response.data;
            console.log(posts);
            setEventList(posts);
            console.log(eventList);
        })
        .catch(function (error) {
            console.log(error);
        })
    }
    var checkEvents = eventList.length>0?true:false;
return(
      <div className="searchBox">
      <h1 className="alert alert-success">Events</h1>
      <form>      
        <br/>   
        <div class="row"> 
          <input id="paccess" type="text" class="form-control" value={access} onChange={(e)=>{setAccess(e.target.value)}}/>
        </div>
        <div class="row">
            <button className="btn btn-success" onClick={getEvents}>Get All Events</button>
        </div>
        </form>
      {checkEvents ? (
        <div>
          {eventList.map((event)=>(
                    <div key={event.eventId} className="alert alert-success">
                    <h6>Event title: {event.title}</h6>
                    <br />
                    Event description: {event.description}
                    <br />
                    Event start datetime: {event.startDateTime}
                    <br />
                    Event end datetime: {event.endDateTime}
                    <br />
                    Event notification datetime: {event.notificationDateTime}
                    <br />
                    Event location: {event.location}
                    <br />
                    Event IsRecurring: {event.isRecurring ? 'Yes' : 'No'}
                    <br />
                    Event recurring frequency: {event.recurring_frequency}
                    <br />
                    Event ShareEventWith: {event.shareEventWith}
                    <br/>
                    Event Access : {event.access}
                    <br/>
                    Event categoryId: {event.categoryId}
                    <br />
                    Event email: {event.email}
                </div>
                ))}
            </div>
      ) : (
        <div>No events available yet</div>
      )}
    </div>
  );
}

export default GetAccess;