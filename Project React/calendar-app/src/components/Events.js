import axios from "axios";
import { useState } from "react";
import MyCalendar from './MyCalendar';


function Events() {
  const [email, setEmail] = useState("");
  const [eventList, setEventList] = useState([]);

  const getEvents = (event) => {
    event.preventDefault();
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

  var checkEvents = eventList.length > 0 ? true : false;

  return (
    <div className="searchBox">
      <h1 className="alert alert-success">Events</h1>
      <form>
        <br />
        <div class="row">
          <input id="pemail" type="text" class="form-control" value={email} onChange={(e) => { setEmail(e.target.value) }} />
        </div>
        <div class="row">
          <button className="btn btn-success" onClick={getEvents}>Get All Events</button>
        </div>
      </form>

      {checkEvents ? (
        <div>
          {eventList.map((group) => (
            <div key={group.key} className="group-container">
              <h5>Category ID: {group.key}</h5>
              <div>
                <MyCalendar events={group}/>
              </div>
            </div>
          ))}
        </div>
      ) : (
        <div>No events available yet</div>
      )}

    </div>
  );
}

export default Events;