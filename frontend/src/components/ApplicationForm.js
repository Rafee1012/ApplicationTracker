import { useState } from "react";
import { addApplication } from "../services/applicationService";
import toast from "react-hot-toast";

function ApplicationForm() {
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

            // Clear form after successful submission
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

export default ApplicationForm;