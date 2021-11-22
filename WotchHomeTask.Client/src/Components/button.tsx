export interface ButtonProps {
  SubmitRequests: () => void;
}

const Button = ({ SubmitRequests }: ButtonProps) => {
  return (
    <>
      <button style={buttonStyle} onClick={SubmitRequests}>
        Send Requests
      </button>
    </>
  );
};

const buttonStyle = {
  color: "white",
  backgroundColor: "black",
  padding: "10px",
  fontFamily: "Arial",
};

export default Button;
