// ExteriorConfiguration.js
import React from "react";
import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";

function ExteriorConfiguration() {

  const [exteriorComponents, setExteriorComponents] = useState([]);
  const { model_id } = useParams();

  useEffect(() => {
    // Fetch interior components from the API based on the model_id

    fetch(`/https://localhost:7139/api/VehicleDetail/ByModel/${model_id}`)
      .then((response) => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        return response.json();
      })
      .then((data) => setExteriorComponents(data))
      .catch((error) =>
        console.error("Error fetching standard components:", error)
      );
  }, [model_id]);

  return (
    <div>
      <h2>Exterior Configuration</h2>
      <p>
        This is the exterior configuration section. Here you can select options
        related to the exterior features of the car.
      </p>
      <div>
        <label htmlFor="color">Color:</label>
        <select id="seats">
          {exteriorComponents.map((component) => (
            <option key={component} value={component}>
              {component}
            </option>
          ))}
        </select>
      </div>
      {/* <div>
        <label htmlFor="wheels">Wheels:</label>
        <select id="wheels">
          <option value="alloy">Alloy</option>
          <option value="steel">Steel</option>
        </select>
      </div> */}
    </div>
  );
}

export default ExteriorConfiguration;
