const API_URL = "http://localhost:5245/api/applications";

export async function getApplications() {
  const response = await fetch(API_URL);

  if (!response.ok) {
    throw new Error("Failed to fetch applications");
  }

  return response.json();
}

export async function addApplication(
  name,
  organization,
  status,
  description
) {
  const application = {
    name: name,
    org: organization,
    status: status,
    desc: description
  };

  const response = await fetch(API_URL, {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(application)
  });

  if (!response.ok) {
    throw new Error("Failed to add application");
  }

  return response.json();
}