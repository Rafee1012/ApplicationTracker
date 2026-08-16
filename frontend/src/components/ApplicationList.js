import { useEffect, useState } from "react";
import { getApplications } from "../services/applicationService";

function ApplicationList() {
  const [applications, setApplications] = useState([]);

  useEffect(() => {
    getApplications()
      .then(data => setApplications(data))
      .catch(error => console.error(error));
  }, []);

  return (
    <div>
      <h2>Applications</h2>
      {applications.map(application => (
        <div key={application.id}>
          <h3>{application.name}</h3>
          <p>{application.organization}</p>
          <p>{application.date}</p>
          <p>{application.desc}</p>
        </div>
      ))}
    </div>
  );
}

export default ApplicationList;