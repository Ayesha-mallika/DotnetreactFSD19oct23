import { useState } from "react";
import "./Category.css";
function Categories(){
    const[categoryList,setCategoryList]=useState([])
    var getCategories=()=>{
        fetch('https://localhost:7211/api/Category',{
            method:'GET',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            }
        }).then(
            async(data)=>{
                var myData = await data.json();
                await console.log(myData);
                await setCategoryList(myData);
            }
        ).catch((e)=>{
            console.log(e)
        })
    }
    var checkCategories=categoryList.length>0?true:false;
    return (
        <div>
          <h1 className="alert alert-info">Categories</h1>
          <button className="btn btn-info" onClick={() => getCategories()}>
            Get All Categories
          </button>
          <hr />
          {checkCategories ? (
            <div>
              {categoryList.map((category) => (
                <div key={category.id} className="alert alert-info">
                  Category Name: {category.name}
                  <br />
                  Category Color: {category.color}
                  
                </div>
              ))}
            </div>
          ) : (
            <div>No categories available yet</div>
          )}
        </div>
      );
    }
    
    export default Categories;