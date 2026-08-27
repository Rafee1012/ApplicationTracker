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
        organization: organization,
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
        const errorText = await response.text();
        console.log("Status:", response.status);
        console.log("Response:", errorText);

        throw new Error(errorText);
    }

    return response.json();
}