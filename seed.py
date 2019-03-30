import subprocess   
subprocess.call(['setx', 'er_random_seed', '3', '/m'], shell=True)
subprocess.call(['setx', 'pex_arithmetic_random_solver_attempts', '0', '/m'], shell=True) 
subprocess.call(['setx', 'pex_arithmetic_random_solver_disabled', 'true', '/m'], shell=True) 
subprocess.call(['setx', 'pex_arithmetic_avm_solver_max_restarts', '0', '/m'], shell=True) 

