import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import "./Registration.css";
import { Link } from "react-router-dom";


export default function Registration() {
  const [formdata, setFormData] = useState({
    Username: "",
    Emailid: "",
    Password: "",
    CompName: "",
    Address: "",
    Telephone: "",
    Holding: "",
    NameAuthPerson: "",
    Designation: "",
    AuthTel: "",
  });
  let navigate = useNavigate();

  const handleChange = (event) => {
    const { name, value } = event.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleSubmit = (event) => {
    event.preventDefault();

    fetch("https://localhost:7139/api/User/signup", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(formdata),
    })
      .then((response) => {
        if (!response.ok) {
          throw new Error(
            `Network response was not ok, status: ${response.status}`
          );
        }
        return response.json(); // Parse JSON response
      })
      .then((data) => {
        console.log("Server response:", data);
        if (data && data.success === true) {
          alert("Successfully registered");
          navigate("/login");
        } else {
          alert("Registration failed: " + (data.message || "Unknown error"));
        }
      })
      .catch((error) => {
        console.error("An error occurred:", error);
        alert("Registration failed. Please try again later.");
      });
  };

  return (
    <div className="feedback-container">
      <div className="image-container">
        <img
          src="https://cdni.iconscout.com/illustration/premium/thumb/contact-us-5795988-4849052.png?f=webp"
          alt="Feedback Image"
          className="feedback-image"
        />
      </div>
      <div className="registration-container">
        <h1>Registration Page</h1>
        <form className="form-group" onSubmit={handleSubmit}>
          <div className="column">
            <label>Email:</label>
            <input type="text" name="Emailid" onChange={handleChange} />
            <label>Username:</label>
            <input type="text" name="Username" onChange={handleChange} />
            <label>Password:</label>
            <input type="password" name="Password" onChange={handleChange} />
            <label>Company Name:</label>
            <input type="text" name="CompName" onChange={handleChange} />
          </div>
          <div className="column">
            <label>Address:</label>
            <input type="text" name="Address" onChange={handleChange} />
            <label>Telephone:</label>
            <input type="text" name="Telephone" onChange={handleChange} />
            <label>Holding:</label>
            <input type="text" name="Holding" onChange={handleChange} />
            <label>Authorized Person Name:</label>
            <input
              type="text"
              name="NameAuthPerson"
              onChange={handleChange}
            />
            <label>Designation:</label>
            <input type="text" name="Designation" onChange={handleChange} />
            <label>Authorized Person Tel:</label>
            <input type="text" name="AuthTel" onChange={handleChange} />
          </div>
          <button type="submit">Submit</button>
          <br />
          <Link to="/">Back</Link>
        </form>
      </div>
    </div>
  );
}

