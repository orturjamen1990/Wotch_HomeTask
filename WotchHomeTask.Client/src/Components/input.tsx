export interface InputProps {
  requestNumber: number | undefined;
  setRequestNumber: any;
}

const Input = ({ requestNumber, setRequestNumber }: InputProps) => {
  return (
    <>
      <input
        style={{ height: 25, width: 150 }}
        min="1"
        max="100"
        type="number"
        pattern="[0-9]*"
        defaultValue={requestNumber}
        onChange={(e) => setRequestNumber(e.target.value)}
      />
    </>
  );
};

export default Input;
