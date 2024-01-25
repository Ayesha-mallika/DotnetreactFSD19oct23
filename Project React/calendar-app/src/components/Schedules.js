import React, { useState } from "react";

function Schedules() {
  const [eventList, setEventList] = useState([]);

  var getEvents = () => {
    fetch("https://localhost:7211/api/event/GetAll", {
      method: "GET",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
    })
      .then(async (data) => {
        var myData = await data.json();
        await setEventList(myData);
      })
      .catch((e) => {
        console.log(e);
      });
  };

  return (
    <div>
      <h1 className="alert alert-info">Events</h1>
      <button className="btn btn-info" onClick={() => getEvents()}>
        Get All Events
      </button>
      <hr />

      {eventList.length > 0 ? (
        
        <ul>
          {eventList.map((event) => (
            <li key={event.id}>
              <strong>{event.title}</strong> 
            </li>
          ))}
        </ul>
      ) : (
        <p>No events available</p>
      )}
    </div>
  );
}

export default Schedules;