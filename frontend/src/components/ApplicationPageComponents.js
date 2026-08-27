import { useEffect, useState } from "react";
import {
    addApplication,
    getApplications
} from "../services/applicationService";
import toast from "react-hot-toast";

export default function ApplicationPageComponents() {
    const [applications, setApplications] = useState([]);

    const refreshApplications = async () => {
        try {
            const data = await getApplications();
            setApplications(data);
        } catch (error) {
            console.error(error);
        }
    };

    useEffect(() => {
        refreshApplications();
    }, []);

    return (
        <div>
            <ApplicationForm onApplicationAdded={refreshApplications} />

            <ApplicationList applications={applications} />
        </div>
    );
}

function ApplicationForm({ onApplicationAdded }) {
    const [name, setName] = useState("");
    const [organization, setOrganization] = useState("");
    const [desc, setDesc] = useState("");
    const [status, setStatus] = useState("Applied");

    const handleSubmit = async (event) => {
        event.preventDefault();

        try {
            const application = await addApplication(
                name,
                organization,
                status,
                desc
            );

            toast.success(`Application added: ${application.name}`, {
                duration: 3000
            });

            // Tell the parent to fetch the updated list
            await onApplicationAdded();

            setName("");
            setOrganization("");
            setDesc("");
            setStatus("Applied");

        } catch (error) {
            toast.error(`Failed to add application: ${error}`, {
                duration: 3000
            });
        }
    };

    return (
        <div>
            <h2>Add Application</h2>

            <form
                onSubmit={handleSubmit}
                style={{
                    display: "flex",
                    alignItems: "flex-end",
                    justifyContent: "center",
                    gap: "15px"
                }}
            >
                <div>
                    <label>Job Title</label>
                    <br />
                    <input
                        type="text"
                        value={name}
                        onChange={(event) => setName(event.target.value)}
                        placeholder="Software Developer"
                    />
                </div>

                <div>
                    <label>Organization</label>
                    <br />
                    <input
                        type="text"
                        value={organization}
                        onChange={(event) => setOrganization(event.target.value)}
                        placeholder="Company"
                    />
                </div>

                <div>
                    <label>Description</label>
                    <br />
                    <input
                        type="text"
                        value={desc}
                        onChange={(event) => setDesc(event.target.value)}
                        placeholder="Description..."
                    />
                </div>

                <div>
                    <label>Status</label>
                    <br />
                    <select
                        value={status}
                        onChange={(event) => setStatus(event.target.value)}
                    >
                        <option value="Applied">Applied</option>
                        <option value="Interview">Interview</option>
                        <option value="Offer">Offer</option>
                        <option value="Rejected">Rejected</option>
                    </select>
                </div>

                <button type="submit">Add Application</button>
            </form>
        </div>
    );
}

function ApplicationList({ applications }) {
    return (
        <div style={{
            maxWidth: "800px",
            margin: "40px auto"
        }}>
            <h2>Applications</h2>

            {applications.length === 0 ? (
                <p>No applications yet.</p>
            ) : (
                applications.map(application => (
                    <div
                        key={application.id}
                        style={{
                            border: "1px solid #ccc",
                            borderRadius: "8px",
                            padding: "20px",
                            marginBottom: "15px",
                            textAlign: "left",
                            boxShadow: "0 2px 5px rgba(0, 0, 0, 0.1)"
                        }}
                    >
                        <h3 style={{ marginTop: "0" }}>
                            {application.name}
                        </h3>

                        <p>
                            <strong>Organization:</strong>{" "}
                            {application.organization}
                        </p>

                        <p>
                            <strong>Status:</strong>{" "}
                            {application.status}
                        </p>

                        <p>
                            <strong>Description:</strong>{" "}
                            {application.desc || "No description"}
                        </p>

                        <p>
                            <strong>Date:</strong>{" "}
                            {application.date}
                        </p>
                    </div>
                ))
            )}
        </div>
    );
}