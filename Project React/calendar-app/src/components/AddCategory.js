import React, { useState } from "react";
import "./AddCategory.css";

function AddCategory() {
  const [name, setName] = useState("");
  const [color, setColor] = useState("");
  var category;

  var clickAdd = () => {
    alert('You clicked the button');
    category = {
      "name": name,
      "color": color
    }
    console.log(category);

    fetch('https://localhost:7211/api/Category', {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body:JSON.stringify(category),
    }).then(() => {
        alert("Category Added");
      })
      .catch((e) => {
        console.log(e);
      })
  }

  return (
    <div className="input-container">
      <label htmlFor="cname">Category Name</label>
      <input
        id="cname"
        type="text"
        value={name}
        onChange={(e) => {setName(e.target.value)}}
      />

      <label htmlFor="ccolor">Category Color</label>
      <input
        id="ccolor"
        type="color"
        value={color}
        onChange={(e) => {setColor(e.target.value)}}
      /><br/>
        <br/>

      <button onClick={clickAdd}>Add Category</button>
    </div>
  );
}

export default AddCategory;