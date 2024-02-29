// ExteriorConfiguration.js
import React from "react";

function ExteriorConfiguration() {
  return (
    <div>
      <h2>Exterior Configuration</h2>
      <p>
        This is the exterior configuration section. Here you can select options
        related to the exterior features of the car.
      </p>
      <div>
        <label htmlFor="color">Color:</label>
        <select id="color">
          <option value="red">Red</option>
          <option value="blue">Blue</option>
          <option value="black">Black</option>
          <option value="white">White</option>
        </select>
      </div>
      <div>
        <label htmlFor="wheels">Wheels:</label>
        <select id="wheels">
          <option value="alloy">Alloy</option>
          <option value="steel">Steel</option>
        </select>
      </div>
    </div>
  );
}

export default ExteriorConfiguration;
